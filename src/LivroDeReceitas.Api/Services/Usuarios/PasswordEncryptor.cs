﻿using System.Security.Cryptography;
using System.Text;

namespace LivroDeReceitas.Api.Services.Usuarios;

public class PasswordEncryptor
{
    public string Encrypt(string senha)
    {
        var bytes = Encoding.UTF8.GetBytes(senha);
        var sha512 = SHA512.Create();
        byte[] hashBytes = sha512.ComputeHash(bytes);
        return StringBytes(hashBytes);
    }

    private string StringBytes(byte[] hashBytes)
    {
        var sb = new StringBuilder();
        foreach (byte b in hashBytes)
        {
            var hex = b.ToString("x2");
            sb.Append(hex);
        }
        return sb.ToString();
    }
}
