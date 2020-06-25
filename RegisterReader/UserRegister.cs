using Microsoft.Win32;

namespace RegisterReader
{
    public static class LerRegUser
    {
        public static void GetUsers()
        {
            CreateUsersCSV addUser = new CreateUsersCSV();

            string UserInfoDirectory = @"SOFTWARE\WOW6432Node\Interactive Intelligence\EIC\Directory Services\Root\ServerName\Production\AdminConfig\UserInfo\";

            RegistryKey LocalMachine = Registry.LocalMachine;
            string[] UserList = LocalMachine.OpenSubKey(UserInfoDirectory).GetSubKeyNames();

            for (int i = 0; i < UserList.Length; i++)
            {
                //GET MAC ADRESS
                string User = UserList[i];
                //GET STATUS (HABILITADA OU NÃO)
                string[] Active = (string[])Registry.GetValue(@"HKEY_LOCAL_MACHINE\" + UserInfoDirectory + UserList[i],
                "Active", new string[] { "No" });
                //GET LICENSE
                string[] License = (string[])Registry.GetValue(@"HKEY_LOCAL_MACHINE\" + UserInfoDirectory + UserList[i],
                "Counted Licenses", new string[] { "Não possui licenças" });

                addUser.ListAddUser(User, Active, License);
            }
            addUser.EscreverUsers();
        }
    }
}
       
