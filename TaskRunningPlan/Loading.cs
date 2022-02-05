using System;
using System.Collections.Generic;
using System.Text;

namespace TaskRunningPlan
{
    public class Loading
    {
        public static void RenderProgress()
        {
            #region loading
            Console.WriteLine("");
            ConsoleColor colorBack = Console.BackgroundColor;
            ConsoleColor colorFore = Console.ForegroundColor;
            
            int index = 0;
            double prePercent = 0;
            List<string> list = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            int count = list.Count;

            //System.Threading.Thread.Sleep(100);//模拟加载等待
            if (count > 0)
            {
                //Console.SetCursorPosition(0, 1);
                Console.WriteLine("");  //Console.WriteLine("Total:" + count);
                //绘制界面
                Console.WriteLine("Loading...");  //Console.WriteLine("********************* Loading *********************");
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                for (int i = 0; ++i <= 50;)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(" ");
                Console.BackgroundColor = colorBack;
                Console.WriteLine("0%");
                //Console.WriteLine("***************************************************");

                foreach (string str in list)
                {
                    #region 绘制界面
                    //绘制界面
                    index++;
                    double percent;
                    if (index <= count)
                    {
                        percent = (double)index / count;
                        percent = Math.Ceiling(percent * 100);
                    }
                    else
                    {
                        percent = 1;
                        percent = Math.Ceiling(percent * 100);
                    }
                    // 开始控制进度条和进度变化
                    for (int i = Convert.ToInt32(prePercent); i <= percent; i++)
                    {
                        //绘制进度条进度                 
                        Console.BackgroundColor = ConsoleColor.Yellow;//设置进度条颜色                
                        Console.SetCursorPosition(i / 2, 3);//设置光标位置,参数为第几列和第几行                
                        Console.Write(" ");//移动进度条                
                        Console.BackgroundColor = colorBack;//恢复输出颜色                
                        //更新进度百分比,原理同上.                
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(0, 4);
                        Console.Write("{0}%", i);
                        Console.ForegroundColor = colorFore;
                        //模拟实际工作中的延迟,否则进度太快
                        System.Threading.Thread.Sleep(10);
                    }
                    prePercent = percent;
                    #endregion
                }

                Console.SetCursorPosition(0, 6);
            }
            //Console.ReadLine();

            #endregion
        }
        
        public static void InputBusiness(out string InputChar,string arg,string msg)
        {
            Console.WriteLine("{0}", msg); 
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            InputChar = consoleKeyInfo.KeyChar.ToString().ToUpper();
            bool isQuit = false;
            while (isQuit == false)
            {
                if (arg.Contains(InputChar))
                {
                    isQuit = true; 
                }
                else
                {
                    Console.WriteLine("{0}", msg);
                    consoleKeyInfo = Console.ReadKey();
                    
                    InputChar = consoleKeyInfo.KeyChar.ToString().ToUpper();
                    isQuit = false;
                }
            }
        }
    }
}
