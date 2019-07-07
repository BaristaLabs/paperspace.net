namespace PaperspaceConsoleTest
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using Paperspace;

    class Program
    {
        private const string PaperspaceNetSampleMachineName = "Paperspace.Net Sample Machine";

        static async Task Main(string[] args)
        {
            // Get configuration
            var config = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
              .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true)
              .Build();

            var client = new PaperspaceClient(config["PAPERSPACE_API_KEY"]);
            var machine = await GetOrCreateMachine(client);
            await MachineCycleSample(client, machine);
            await ResourceDelegationSample(client, machine);
            await DestroyMachine(client, machine);

            await ScriptFullLifecycleSample(client);
            await NetworksSample(client);
            await UsersSample(client);

            Console.WriteLine("All done!!");
        }

        static async Task<Machine> GetOrCreateMachine(IPaperspaceClient client)
        {
            // ----
            // List all Windows 10 templates
            // ----
            var templates = await client.Templates.List(new TemplateFilter() { Label = "Windows 10" });
            Console.WriteLine("Listing Templates...");
            Console.WriteLine(JsonConvert.SerializeObject(templates, Formatting.Indented));

            var template = templates.FirstOrDefault(t => t.OS == "Windows 10 (Server 2019) - Licensed");

            if (template == null)
            {
                throw new InvalidOperationException("Unable to locate Windows 10 template.");
            }

            // ----
            // Check Availability for a GPU machine
            // ----

            Console.WriteLine("Checking GPU Availability...");
            var availability = await client.Machines.Availability(Region.EastCoast_NY2, MachineType.GPUPlus);
            Console.WriteLine(JsonConvert.SerializeObject(templates, Formatting.Indented));

            // ----
            // List Machines
            // ----

            Console.WriteLine("Listing Machines...");
            var machines = await client.Machines.List(new MachineFilter()
            {
                Name = PaperspaceNetSampleMachineName
            });

            // ----
            // If a Paperspace.Net Sample Machine didn't exist, create a new Machine, otherwise start the existing.
            // ----

            var newMachine = machines.FirstOrDefault(m => m.Name == PaperspaceNetSampleMachineName);
            if (newMachine == null)
            {
                Console.WriteLine("Creating new machine...");
                newMachine = await client.Machines.Create(new CreateMachineRequest
                {
                    Region = Region.EastCoast_NY2,
                    MachineType = MachineType.Air,
                    Size = 50,
                    BillingType = BillingType.Hourly,
                    MachineName = PaperspaceNetSampleMachineName,
                    TemplateId = template.Id,
                });
            }
            else
            {
                await client.Machines.Start(newMachine.Id);
            }

            Console.WriteLine($"Machine with the id of {newMachine.Id} is now {newMachine.State}");
            newMachine = await client.Machines.Waitfor(newMachine.Id, MachineState.Ready, 5000, 0, (m) => Console.WriteLine(m.State));
            Console.WriteLine($"Machine with the id of {newMachine.Id} is now {newMachine.State}");

            return newMachine;
        }

        /// <summary>
        /// Demonstrates cycling a machine: List -> Stop -> Start -> Restart -> Utilization
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        static async Task MachineCycleSample(IPaperspaceClient client, Machine machine)
        {
            Console.WriteLine("Listing Machines...");
            var machines = await client.Machines.List();
            Console.WriteLine(JsonConvert.SerializeObject(machines, Formatting.Indented));

            // ----
            // Stop the machine we created.
            // ----

            Console.WriteLine($"Stopping {machine.Id}...");
            await client.Machines.Stop(machine.Id);
            machines = await client.Machines.List();
            machine = await client.Machines.Waitfor(machine.Id, MachineState.Off, 5000, 0, (m) => Console.WriteLine(m.State));

            Console.WriteLine($"Machine with the id of {machine.Id} is now {machine.State}");

            // ----
            //Start the machine we created.
            // ----
            Console.WriteLine($"Starting {machine.Id}...");
            await client.Machines.Start(machine.Id);
            machines = await client.Machines.List();
            machine = await client.Machines.Waitfor(machine.Id, MachineState.Ready, 5000, 0, (m) => Console.WriteLine(m.State));

            Console.WriteLine($"Machine with the id of {machine.Id} is now {machine.State}");

            // ----
            // Restart the machine we created.
            // ----
            Console.WriteLine($"Restarting {machine.Id}...");
            await client.Machines.Restart(machine.Id);
            machines = await client.Machines.List();
            machine = await client.Machines.Waitfor(machine.Id, MachineState.Ready, 5000, 0, (m) => Console.WriteLine(m.State));

            Console.WriteLine($"Machine with the id of {machine.Id} is now {machine.State}");

            // ----
            // Get machine utilization.
            // ----
            var currentDate = DateTime.Now;
            var utilization = await client.Machines.Utilization(machine.Id, currentDate.ToString("YYYY-MM"));
            Console.WriteLine(JsonConvert.SerializeObject(utilization, Formatting.Indented));
        }

        /// <summary>
        /// Demonstrates destroying a machine.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="machine"></param>
        /// <returns></returns>
        static async Task DestroyMachine(IPaperspaceClient client, Machine machine)
        {
            // ----
            // List machines and then destroy the machine we created.
            // ----

            Console.WriteLine("Listing Machines...");
            var machines = await client.Machines.List();
            Console.WriteLine(JsonConvert.SerializeObject(machines, Formatting.Indented));

            Console.WriteLine($"Destroying {machine.Id}...");
            await client.Machines.Destroy(machine.Id);

            Console.WriteLine("Listing Machines...");
            machines = await client.Machines.List();
            Console.WriteLine(JsonConvert.SerializeObject(machines, Formatting.Indented));
        }

        /// <summary>
        /// Demonstrates the Networks Client
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        static async Task NetworksSample(IPaperspaceClient client)
        {
            Console.WriteLine("Listing Networks...");
            var networks = await client.Networks.List();
            Console.WriteLine(JsonConvert.SerializeObject(networks, Formatting.Indented));
        }

        /// <summary>
        /// Demonstrates a full Script lifecycle: Create -> List -> Show -> Text -> Destroy
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        static async Task ScriptFullLifecycleSample(IPaperspaceClient client)
        {
            // ----
            // Create a new Script
            // ----

            Console.WriteLine("Creating new script...");
            var newScript = await client.Scripts.Create(new CreateScriptRequest
            {
                ScriptName = "My Script",
                ScriptText = "echo Hello, World!",
                ScriptDescription = "A startup script",
                IsEnabled = true,
                RunOnce = false
            });

            Console.WriteLine($"A new script with the id of {newScript.Id} has been created.");

            Console.WriteLine($"Listing Scripts...");
            var scripts = await client.Scripts.List();
            Console.WriteLine(JsonConvert.SerializeObject(scripts, Formatting.Indented));

            // ----
            // Show the script we created
            // ----
            Console.WriteLine($"Showing script {newScript.Id}...");
            var script = await client.Scripts.Show(newScript.Id);
            Console.WriteLine(JsonConvert.SerializeObject(script, Formatting.Indented));

            // ----
            // Get the text of the script we created
            // ----
            Console.WriteLine($"Showing script text of {newScript.Id}...");
            var text = await client.Scripts.Text(newScript.Id);
            Console.WriteLine(text);

            // ----
            // Destroy script we created
            // ----
            Console.WriteLine($"Destroying {newScript.Id}...");
            await client.Scripts.Destroy(newScript.Id);

            scripts = await client.Scripts.List();
            Console.WriteLine(JsonConvert.SerializeObject(scripts, Formatting.Indented));

            // ----
            // Create a new Script using a filename
            // ----

            Console.WriteLine("Creating new script...");
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes("echo Foo, Bar, Baz!")))
            {
                newScript = await client.Scripts.Create(new CreateScriptRequest
                {
                    ScriptName = "My Script",
                    ScriptFile = "./foobar.ps1",
                    ScriptDescription = "A startup script",
                    IsEnabled = true,
                    RunOnce = false
                }, ms);

                Console.WriteLine($"Showing script text of {newScript.Id}...");
                text = await client.Scripts.Text(newScript.Id);
                Console.WriteLine(text);

                Console.WriteLine($"Destroying {newScript.Id}...");
                await client.Scripts.Destroy(newScript.Id);
            }
        }

        /// <summary>
        /// Demonstrates the Users Client
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        static async Task UsersSample(IPaperspaceClient client)
        {
            Console.WriteLine("Listing Users...");
            var users = await client.Users.List();
            Console.WriteLine(JsonConvert.SerializeObject(users, Formatting.Indented));
        }

        /// <summary>
        /// Demonstrates the ResourceDelegations Client
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        static async Task ResourceDelegationSample(IPaperspaceClient client, Machine machine)
        {
            Console.WriteLine("Creating Resource Delegation...");
            var resourceDelegations = await client.ResourceDelegations.Create(new CreateResourceDelegationRequest()
            {
                Machine = new CreateResourceDelegationMachine()
                {
                    Ids = new List<string>() { machine.Id }
                }
            });
            Console.WriteLine(JsonConvert.SerializeObject(resourceDelegations, Formatting.Indented));
        }

        static async Task JobsSample(IPaperspaceClient client)
        {
            Console.WriteLine("Listing Job Machine Types...");
            var machineTypes = await client.Jobs.MachineTypes();
            Console.WriteLine(JsonConvert.SerializeObject(machineTypes, Formatting.Indented));
        }
    }
}
