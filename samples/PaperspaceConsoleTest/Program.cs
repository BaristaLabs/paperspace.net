namespace PaperspaceConsoleTest
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using Paperspace;

    class Program
    {
        static async Task Main(string[] args)
        {
            // Get configuration
            var config = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
              .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true)
              .Build();

            var client = new PaperspaceClient(config["PAPERSPACE_API_KEY"]);
            // await MachineFullLifecycleSample(client);
            await ScriptFullLifecycleSample(client);

            Console.WriteLine("All done!!");
        }

        /// <summary>
        /// Demonstrates a full Machine lifecycle: Create -> Stop -> Start -> Restart -> Destroy
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        static async Task MachineFullLifecycleSample(IPaperspaceClient client)
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
            // Create a new Machine
            // ----

            Console.WriteLine("Creating new machine...");
            var newMachine = await client.Machines.Create(new CreateMachineRequest
            {
                Region = Region.EastCoast_NY2,
                MachineType = MachineType.Air,
                Size = 50,
                BillingType = BillingType.Hourly,
                MachineName = "My Machine 1",
                TemplateId = template.Id,
            });

            Console.WriteLine($"A new machine with the id of {newMachine.Id} is now {newMachine.State}");

            newMachine = await client.Machines.Waitfor(newMachine.Id, MachineState.Ready, 5000, 0, (m) => Console.WriteLine(m.State));

            Console.WriteLine($"Machine with the id of {newMachine.Id} is now {newMachine.State}");

            Console.WriteLine("Listing Machines...");
            var machines = await client.Machines.List();
            Console.WriteLine(JsonConvert.SerializeObject(machines, Formatting.Indented));

            // ----
            // Stop the machine we created.
            // ----

            Console.WriteLine($"Stopping {newMachine.Id}...");
            await client.Machines.Stop(newMachine.Id);
            machines = await client.Machines.List();
            newMachine = await client.Machines.Waitfor(newMachine.Id, MachineState.Off, 5000, 0, (m) => Console.WriteLine(m.State));

            Console.WriteLine($"Machine with the id of {newMachine.Id} is now {newMachine.State}");

            // ----
            //Start the machine we created.
            // ----
            Console.WriteLine($"Starting {newMachine.Id}...");
            await client.Machines.Start(newMachine.Id);
            machines = await client.Machines.List();
            newMachine = await client.Machines.Waitfor(newMachine.Id, MachineState.Ready, 5000, 0, (m) => Console.WriteLine(m.State));

            Console.WriteLine($"Machine with the id of {newMachine.Id} is now {newMachine.State}");

            // ----
            // Restart the machine we created.
            // ----

            Console.WriteLine($"Restarting {newMachine.Id}...");
            await client.Machines.Restart(newMachine.Id);
            machines = await client.Machines.List();
            newMachine = await client.Machines.Waitfor(newMachine.Id, MachineState.Ready, 5000, 0, (m) => Console.WriteLine(m.State));

            Console.WriteLine($"Machine with the id of {newMachine.Id} is now {newMachine.State}");

            // ----
            // List machines and then destroy the machine we created.
            // ----

            Console.WriteLine("Listing Machines...");
            machines = await client.Machines.List();
            Console.WriteLine(JsonConvert.SerializeObject(machines, Formatting.Indented));

            Console.WriteLine($"Destroying {newMachine.Id}...");
            await client.Machines.Destroy(newMachine.Id);

            Console.WriteLine("Listing Machines...");
            machines = await client.Machines.List();
            Console.WriteLine(JsonConvert.SerializeObject(machines, Formatting.Indented));
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
            // Get the text of the script we cdreated
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
        }
    }
}
