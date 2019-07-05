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

            //List templates
            var templates = await client.Templates.List(new TemplateFilter() { Label = "Windows 10" });
            Console.WriteLine("Listing Templates...");
            Console.WriteLine(JsonConvert.SerializeObject(templates, Formatting.Indented));

            var template = templates.FirstOrDefault(t => t.OS == "Windows 10 (Server 2019) - Licensed");

            if (template == null)
            {
                throw new InvalidOperationException("Unable to locate Windows 10 template.");
            }

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

            Console.WriteLine("All done!!");
        }
    }
}
