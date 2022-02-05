using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarGateway.ModelApi
{
    public class NameCls
    {
        public static NameStruct SplitName(string Name)
        {
            NameStruct nameStruct = new NameStruct();
            if (Name.IndexOf(' ')!=-1)
            {
                string[] NameArr = Name.Split(' ');

                nameStruct.LastName = NameArr[0];

                for(int i=1;i< NameArr.Length;i++)
                {
                    nameStruct.FirtName += " " + NameArr[i];
                }
                nameStruct.FirtName.TrimStart(' ');
                nameStruct.FirtName.TrimEnd(' ');
            }else
            {
                nameStruct.LastName = "";
                nameStruct.FirtName = Name;
            }
            
            return nameStruct;
        } 
    }

    public class NameStruct
    {
        public string FirtName;
        public string LastName;
    }
}
