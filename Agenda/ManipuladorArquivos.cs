using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    public class ManipuladorArquivos
    {
        private const string expMessage = "O arquivo não existe";
        private static string EnderecoArquivo = AppDomain.CurrentDomain.BaseDirectory + "contatos.txt";
        public static List<Contato> LerArquivo()
        {
            List<Contato> listContatos = new List<Contato>();
            if (File.Exists(@EnderecoArquivo))
            {
                using (StreamReader sr = File.OpenText(@EnderecoArquivo))
                {
                    while (sr.Peek() >= 0)
                    {
                        string linha = sr.ReadLine();
                        string[] values = linha.Split(';');
                        if(values.Count() == 3)
                        {
                            listContatos.Add(new Contato(values[0], values[1], values[2]));
                        }
                    }
                }
            }
            else
            {
                return listContatos;
            }
            return listContatos;
        }

        public static void EscreverArquivo(List<Contato> contatosLista)
        {

            using (StreamWriter sw = new StreamWriter(@EnderecoArquivo, true))
            {
                foreach (Contato contato in contatosLista)
                {
                    string linha = string.Format("{0};{1};{2}", contato.Nome, contato.Email, contato.NumeroTelefone);
                    sw.WriteLine(linha);
                }
                sw.Flush();
            }
        }
    }
}
