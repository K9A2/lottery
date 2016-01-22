using System;
using System.Windows.Forms;

namespace 抽奖软件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] balls = new int[20];                                      //所有的球
            int[] ran_10 = new int[10];                                     //随机得出分数为10的球的编号
            int[] fortune = new int[10];                                    //抽到的球的随机编号
            int sum = 0;                                                    //抽到的分数的总和
            int count_5 = 0;                                                //抽到5分的球的数目
            int count_10 = 0;                                               //抽到10分你的球的数目
            getInitValue(balls, 0);                                         //给balls赋初值0
            getInitValue(fortune, 0);                                       //给fortune赋初值0
            getNotRepeatedRandomNumbers(ran_10, 0, 20);                     //选出10个值为10的球
            for(int i = 0; i < ran_10.Length; i++)                          //给选中的值为10的球赋值
            {
                balls[ran_10[i]] = 10;
            }
            for(int i = 0; i < balls.Length; i++)                           //给值为5的球赋值
            {
                if (balls[i] != 10)
                {
                    balls[i] = 5;
                }
            }
            System.Threading.Thread.Sleep(10);
            getNotRepeatedRandomNumbers(fortune, 0, 20);                    //选出要抽的球的编号
            for(int i=0;i<fortune.Length; i++)                              //抽奖
            {
                if (balls[fortune[i]] == 10)
                {
                    count_10++;
                }
                else if(balls[fortune[i]]==5)
                {
                    count_5++;
                }
                sum = sum + balls[fortune[i]];
            }
            textBox1.AppendText("您一共抽到了"+count_5+"个5分的球和"+count_10+"个10分的球"+
                "总分数为:"+sum+Environment.NewLine+"恭喜您!"+
                Environment.NewLine+Environment.NewLine);
        }

        public static void getInitValue(int[] array,int initValue)
        {
            //给array里面的所有元素赋initValue
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = initValue;
            }
        }

        public static void getNotRepeatedRandomNumbers(int[] array, int min, int max)
        {
            //给array里面的元素不重复地赋min到max之间的随机数
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
            loop: int randomnumber = random.Next(min, max);                //先得出此随机数字
                for (int j = 0; j < array.Length; j++)                    //检查其是否重复
                {
                    if (randomnumber == array[j])
                    {
                        goto loop;                                          //如果重复,则重新开始此循环
                    }
                }
                array[i] = randomnumber;
            }
        }
    }
}
