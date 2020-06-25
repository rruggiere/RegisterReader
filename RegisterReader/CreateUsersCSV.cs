using System.IO;
using System.Collections.Generic;

namespace RegisterReader
{
    class CreateUsersCSV
    {
        public List<Users> ListUsers { get; set; }
        public static string DataHora = System.DateTime.Now.ToString();
        public string Caminho = @"C:\Temp\UsersHP_" + DataHora.Substring(0, 10).Replace('/', '-') + ".csv";

        public CreateUsersCSV()
        {
            ListUsers = new List<Users>();
        }
        public void ListAddUser(string _User, string[] _Active, string[] _Licenses)
        {
            Users NewUsers = new Users {UserID = _User, Active = _Active, Licenses = _Licenses };
            ListUsers.Add(NewUsers);
        }

        public void EscreverUsers()
        {
            FileStream ListaStream = new FileStream(Caminho, FileMode.Create);
            StreamWriter ListaCSV = new StreamWriter(ListaStream, System.Text.Encoding.UTF8);

            ListaCSV.WriteLine("ID;Site;Licença");

            for (int i = 0; i < ListUsers.Count; i++)
            {
                ListaCSV.Write(ListUsers[i].UserID);
                ListaCSV.Write(ListUsers[i].Active[0]);
                for (int i2 = 0; i2 < ListUsers[i].Licenses.Length; i2++)
                {
                    ListaCSV.Write(i2 == 0 ? "{0}" : " - {0}", ListUsers[i].Licenses[i2]);
                }

                ListaCSV.WriteLine();
            }
            ListaCSV.Write("Arquivo gerado em " + DataHora);
            ListaCSV.Close();
        }
    }
}


