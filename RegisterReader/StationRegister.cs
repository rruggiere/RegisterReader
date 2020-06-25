using Microsoft.Win32;

namespace RegisterReader
{
    public static class StationRegisters
    {
      public static void GetStations()
       {
         CrateStationCSV addStation = new CrateStationCSV();
         string WorkStationDirectory = @"SOFTWARE\Wow6432Node\Interactive Intelligence\EIC\Directory Services\Root\HP\Production\ServerName\Workstations\";
         string StationInfoDirectory = @"SOFTWARE\WOW6432Node\Interactive Intelligence\EIC\Directory Services\Root\HHP\Production\AdminConfig\StationInfo\";
         RegistryKey LocalMachine = Registry.LocalMachine;
         string[] StationsList = LocalMachine.OpenSubKey(WorkStationDirectory).GetSubKeyNames();
            
         for (int i = 0; i < StationsList.Length; i++)
          {
            //GET MAC ADRESS
            string[] Site = (string[])Registry.GetValue(@"HKEY_LOCAL_MACHINE\" + WorkStationDirectory + StationsList[i],
            "MAC Address", new string[] { "Não possui site" });
            //GET STATUS (HABILITADA OU NÃO)
            string[] Active = (string[])Registry.GetValue(@"HKEY_LOCAL_MACHINE\" + StationInfoDirectory + StationsList[i],
            "Active", new string[] { "No" });
            //GET LICENSE
            string[] License = (string[])Registry.GetValue(@"HKEY_LOCAL_MACHINE\" + WorkStationDirectory + StationsList[i],
            "Counted Licenses", new string[] { "Não possui licenças" });

            addStation.ListAddStation(StationsList[i], Site, Active, License);
         }
         addStation.EscreverStations();
      }
    }
}

