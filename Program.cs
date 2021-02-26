using Series.Classes;
using System;

namespace Series
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();
        static void Main(string[] args)
        {
            string userOption = ObtainUserOptions();
            while(userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InsertSerie();
                        break;
                    case "3":
                        UpdateSerie();
                        break;
                    case "4":
                        DeleteSerie();
                        break;
                    case "5":
                        ViewSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                userOption = ObtainUserOptions();
            }

            Console.WriteLine("Hello World!");
        }

        private static void ViewSerie()
        {
            Console.WriteLine("Digite o ID da série: ");
            int serieID = int.Parse(Console.ReadLine());

            var serie = repository.ReturnById(serieID);

            Console.WriteLine(serie);
        }

        private static void DeleteSerie()
        {
            Console.WriteLine("Digite o ID da série: ");
            int serieID = int.Parse(Console.ReadLine());

            repository.Delete(serieID);
        }

        private static void ListSeries()
        {
            var list = repository.List();
            if(list.Count == 0)
            {
                Console.WriteLine("Nenhuma serie encontrada");
            }
            else
            {
                foreach (var serie in list)
                {
                    var deleted = serie.ReturnDeleted();
                    Console.WriteLine("#ID {0}: - {1} {2}", serie.Id, serie.returnTitle(), (deleted ? "**Excluído":""));
                    
                }
            }
            
        }

        private static void InsertSerie()
        {
            Serie newSerie = CreateSerieObject(repository.NextId());
            repository.Insert(newSerie);
        }

        private static Serie CreateSerieObject(int id)
        {
            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int genreEntry = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da série: ");
            string titleEntry = Console.ReadLine();

            Console.WriteLine("Digite o ano da série: ");
            int yearEntry = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série: ");
            string descriptionEntry = Console.ReadLine();

            Serie newSerie = new Serie(id: id,
                                        genre: (Genre)genreEntry,
                                        title: titleEntry,
                                        year: yearEntry,
                                        description: descriptionEntry);
            return newSerie;
        }

        private static void UpdateSerie()
        {
            Console.WriteLine("Digite o Id da série: ");
            int serieId = int.Parse(Console.ReadLine());
            Serie serie = CreateSerieObject(serieId);
            repository.Update(serieId, serie);
        }

        private static string ObtainUserOptions()
        {
            Console.WriteLine();
            Console.WriteLine("APP Séries ao seu dispôr!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
