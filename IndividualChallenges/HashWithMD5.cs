using System;
using System.Security.Cryptography;

public void HashWithSHA256(byte[] data)
{
    using (var sha256 = SHA256.Create())
    {
        var hash = sha256.ComputeHash(data);
        Console.WriteLine($"SHA-256 Hash: {Convert.ToHexString(hash)}");
    }
}
