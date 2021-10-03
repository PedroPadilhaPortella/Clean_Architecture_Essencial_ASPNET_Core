using System;

namespace ModeloAnemico1
{
    public sealed class Cliente
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Endereco { get; private set; }

        public Cliente(int id, string nome, string endereco)
        {
            this.Validar(id, nome, endereco);
            this.Id = id;
            this.Nome = nome;
            this.Endereco = endereco;
        }

        public void Update(int id, string nome, string endereco)
        {
            this.Validar(id, nome, endereco);
            this.Id = id;
            this.Nome = nome;
            this.Endereco = endereco;
        }

        public void Validar(int id, string nome, string endereco)
        {
            if(id < 0) 
                throw new InvalidOperationException("Id must be greater than 0");

            if(nome.Length < 3 || nome.Length > 100) 
                throw new InvalidOperationException("Nome must have length between 3 and 100 characters");
        }
    }
}