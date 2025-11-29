// See https://aka.ms/new-console-template for more information
using BCrypt.Net;

Console.WriteLine("Hello, World!");


string newPlainTextPassword = "jobamed123!";

// Generate the hash
string newPasswordHash = BCrypt.Net.BCrypt.HashPassword(newPlainTextPassword, 12); // Use a cost factor like 12 for security

Console.WriteLine("Plain Text Password: " + newPlainTextPassword);
Console.WriteLine("Generated BCrypt Hash (Copy this):");
Console.WriteLine(newPasswordHash);
Console.ReadKey(); 