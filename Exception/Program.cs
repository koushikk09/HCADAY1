using System;
using System.Linq;
using Bogus;

namespace PatientConsole
{
    // Model representing a patient in our healthcare system
    public class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public string City { get; set; } = "";
        public bool Active { get; set; }
    }

    internal class Program
    {
        static void Main()
        {
            // Create a fake-data generator for the Patient class
            var patientGenerator = new Faker<Patient>()
                .RuleFor(p => p.PatientId,
                    f => f.Random.Number(1000, 9999))
                .RuleFor(p => p.Name,
                    f => f.Name.FullName())
                .RuleFor(p => p.Age,
                    f => f.Random.Number(18, 90))
                .RuleFor(p => p.City,
                    f => f.Address.City())
                .RuleFor(p => p.Active,
                    f => f.Random.Bool());

            // Generate 1000 fake patient records
            var patients = patientGenerator.Generate(1000);

            Console.WriteLine($"Generated {patients.Count} fake patients");
            Console.WriteLine();

            foreach (var patient in patients.Take(10))
            {
                Console.WriteLine(
                    $"ID: {patient.PatientId} | " +
                    $"Name: {patient.Name} | " +
                    $"Age: {patient.Age} | " +
                    $"City: {patient.City} | " +
                    $"Active: {patient.Active}"
                );
            }
        }
    }
}