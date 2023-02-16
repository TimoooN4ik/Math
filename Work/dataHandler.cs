using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Work
{
    class dataHandler
    {
        AppContext db;

        public void read()
        {
            string path = Environment.CurrentDirectory;
            string usless = "\\bin\\Debug";
            path = path.Substring(0, path.Length - usless.Length);

            db = new AppContext();

            string s = "";

            try
            {
                List<FHC> fhc = db.FHCs.ToList();
                foreach (FHC fh in fhc)
                    s += fh.b0;
                if (s != "")
                    return;
            }
            catch(Exception ex)
            {
                StreamWriter sw = new StreamWriter(path + "\\log.txt");
                sw.WriteLine(ex.Message);
                sw.Close();
                //записать это в логи, проверить чтение из файла
            }

            StreamReader sr = new StreamReader(path + "\\data.txt");
            string line;
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();

                switch(line[0])
                {
                    case '0':
                        break;
                    case '1':
                        break;
                    case '-':
                        break;
                    case '*':
                        continue;

                    default:
                        break;
                }
            }
        }
    }
}
