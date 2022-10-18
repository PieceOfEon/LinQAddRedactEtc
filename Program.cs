using System.Reflection.Metadata;

var people = new List<Person>();

char vvod;
do
{
    Console.Clear();
    Console.WriteLine("1 - Заполнение книги");
    Console.WriteLine("2 - Поиск по имени");
    Console.WriteLine("3 - Поиск по номеру");
    Console.WriteLine("4 - Поиск по первой букве алфавита");
    Console.WriteLine("5 - Поиск по слогану для фамилии");
    Console.WriteLine("6 - Посмотреть книгу");
    Console.WriteLine("Выход - Esc");
    
    vvod = Console.ReadKey().KeyChar;
    switch (vvod)
    {
        case '1':
            {
                Console.Clear();
                string Name;
                Console.WriteLine("Введите имя");
                Name = Console.ReadLine();
                string SecondName;
                Console.WriteLine("Введите фамилию");
                SecondName = Console.ReadLine();
                string num;
                Console.WriteLine("Введите номер телефона");
                num = Console.ReadLine();
                people.Add(new Person(Name, SecondName, num));
                
                Console.ReadKey();
                break;
            }
        case '2':
            {
                Console.Clear();
                string name;
                Console.WriteLine("Введитя имя для поиска");
                name = Console.ReadLine();
                var searchPeople = from pers2 in people
                                   where pers2.Name == name
                                   select pers2;
                foreach (var pers2 in searchPeople)
                {
                    Console.WriteLine(pers2 + " ");
                }
                Console.ReadKey();
                break;
            }
        case '3':
            {
                Console.Clear();
                string num;
                Console.WriteLine("Введите номер телефона для поиска");
                num=Console.ReadLine();
                var searchPeople2 = from pers3 in people
                                    where pers3.num == num
                                    select pers3;
                foreach (var pers3 in searchPeople2)
                {
                    Console.WriteLine(pers3 + " ");
                }

                Console.ReadKey();
                break;
            }
        case '4':
            {
                Console.Clear();
                string one;
                Console.WriteLine("Введите первую букву для поиска по первой букве(фамилия)");
                one = Console.ReadLine();
                one = one.ToUpper();
                var sortSecondName = from pers4 in people
                                     where pers4.SecondName.ToUpper().ElementAt(0) == Convert.ToChar(one[0])
                                     select pers4;
                foreach (var pers4 in sortSecondName)
                {
                    Console.WriteLine(pers4 + " ");
                }
                Console.ReadKey();
                break;
            }
        case '5':
            {
                Console.Clear();
                string slog;
                Console.WriteLine("Введите слоган");
                slog = Console.ReadLine();
                slog = slog.ToUpper();
                var sortSlogan = from pers5 in people
                                 where pers5.SecondName.ToUpper().Contains(slog)
                                 orderby pers5.SecondName
                                 select pers5;
                foreach (var pers5 in sortSlogan)
                {
                    Console.WriteLine(pers5 + " ");
                }
                Console.ReadKey();
                break;
            }
        case '6':
            {
                Console.Clear();
                var sortPeople = from pers in people
                                 orderby pers.Name
                                 select pers;
                foreach (var pers in sortPeople)
                {
                    Console.WriteLine(pers + " ");
                }
                Console.ReadKey();
                break;
            }
        case '7':
            {
                Console.Clear();
                Console.WriteLine("Введите имя для поиска");
                string newName = Console.ReadLine();
                Console.WriteLine("Введите имя для замены");
                string str = Console.ReadLine();

                for (int i = 0; i < people.Count; i++)
                {
                    if (people[i].Name.ToUpper()==newName.ToUpper())
                    {
                        Person tmp = new(str, people[i].SecondName, people[i].num);
                        people[i] = tmp;
                        break;
                    }
                }
                Console.ReadKey();
                break;
            }
    }
} while (vvod != 27);
record class Person(string Name, string SecondName, string num);
