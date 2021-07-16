using System.IO;
using System;
using System.Text;

namespace FileSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            char sair = 'n';
            while (sair != 's')
            {
                Console.Clear();
                Console.Write("Insira o caminho do directorio onde pretende criar ou modificar arquivos: ");
                string path = Console.ReadLine();
                if (!path.EndsWith(@"\")) path += @"\";
                Console.Write("Pretende criar ou apagar(c/a)? ");
                char ch = char.Parse(Console.ReadLine());
                Console.Write("Arquivos ou Pastas (A/P): ");
                char res = char.Parse(Console.ReadLine());
                string escrita = null;
                int cont = 0;

                try
                {
                    if (ch == 'c' && res == 'A')
                    {
                        Console.Write("Insira o nome do Arquivo a criar e extensão: ");
                        string final = Console.ReadLine();
                        using (File.Create(path + final))
                            Console.Write("Deseja Escrever no arquivo? (s/n)");
                        char ch1 = char.Parse(Console.ReadLine());
                        if (ch1 == 's')
                        {
                            Console.WriteLine("Insira o texto abaixo, use a virgula para representar quebra de linha: ");
                            escrita = Console.ReadLine();
                            foreach (char word in escrita)
                            {
                                if (word == ',') cont++;
                            }
                            using (StreamWriter sr = File.AppendText(path + final))
                            {
                                for (int i = 0; i <= cont; i++)
                                {
                                    string[] vect = escrita.Split(',');
                                    sr.WriteLine(vect[i]);
                                }
                            }
                        }
                    }
                    else if (ch == 'a' && res == 'A')
                    {
                        Console.Write("Insira o nome do Arquivo a apagar: ");
                        string apagar = Console.ReadLine();
                        File.Delete(path + apagar);
                        Console.WriteLine("O ficheiro " + path + apagar + " foi apagado");
                    }
                    else if (ch == 'c' && res == 'P')
                    {
                        Console.Write("Insira o nome da Pasta a criar: ");
                        string criarPasta = Console.ReadLine();
                        Directory.CreateDirectory(path + criarPasta);
                    }
                    else
                    {
                        Console.Write("Insira a Pasta a apagar: ");
                        string apagarPasta = Console.ReadLine();
                        Directory.Delete(path + apagarPasta);
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("Error! : " + e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error! " + e.Message);
                }
                Console.Write("Deseja sair(s/n)? ");
                sair = char.Parse(Console.ReadLine());
            }
        }
    }
}
