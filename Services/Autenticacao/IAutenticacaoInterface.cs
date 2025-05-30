﻿using Biblioteca.Models;

namespace Biblioteca.Services.Autenticacao
{
    public interface IAutenticacaoInterface
    {
        void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt);
        bool VerificaSenhaHash(string senha, byte[] senhaHash, byte[] senhaSalt);
        string CriarToken(UsuarioModel usuario);
    }
}
