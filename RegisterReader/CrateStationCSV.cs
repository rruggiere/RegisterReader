using System;
using System.IO;
using System.Collections.Generic;

namespace RegisterReader
{
    class CrateStationCSV
    {
        public List<Station> ListStations { get; set; }
        public static string DataHora = DateTime.Now.ToString();
        public string Caminho = @"C:\Temp\StationsHP_" + DataHora.Substring(0, 10).Replace('/', '-')
            + ".csv";
        public CrateStationCSV()
        {
            ListStations = new List<Station>();
        }
        public void ListAddStation(string _StationID, string[] _Site, string[] _Active, string[] _Licenses)
        {
            Station NewStation = new Station { StationID = _StationID, Site = _Site, Active = _Active, Licenses = _Licenses };
            ListStations.Add(NewStation);
        }
        public void EscreverStations()
        {
            FileStream ListaStream = new FileStream(Caminho, FileMode.Create);
            StreamWriter ListaCSV = new StreamWriter(ListaStream, System.Text.Encoding.UTF8);

            ListaCSV.WriteLine("{0},{1},{2},{3}", "ID", "Site", "Ativo", "Licenca");

            for (int i = 0; i < ListStations.Count; i++)
            {
                
                ListaCSV.Write("{0},{1},{2},", ListStations[i].StationID, ListStations[i].Site[0],
                    ListStations[i].Active[0]);
                for (int i2 = 0; i2 < ListStations[i].Licenses.Length; i2++)
                {
                    ListaCSV.Write(i2 == 0 ? "{0}" : " - {0}", ListStations[i].Licenses[i2]);
                }
                ListaCSV.WriteLine();
            }
            ListaCSV.Write("Arquivo gerado em " + DataHora);
            ListaCSV.Close();
        }
    }
}
