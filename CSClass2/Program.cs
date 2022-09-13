﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSClass2
{
    class Program
    {
        static void Main(string[] args)
        {
            // 제네릭
            Wanted<string> wantedString = new Wanted<string>("String");
            Wanted<int> wantedInt = new Wanted<int>(52273);
            Wanted<double> wantedDouble = new Wanted<double>(52.273);

            Console.WriteLine(wantedString.Value);
            Console.WriteLine(wantedInt.Value);
            Console.WriteLine(wantedDouble.Value);

            // 인덱서
            Products p = new Products();
            Console.WriteLine(p[4]);
            p[4] = 5;

            // out 키워드
            Console.WriteLine("숫자 입력 : ");
            int output;
            bool result = int.TryParse(Console.ReadLine(), out output);
            if (result)
            {
                Console.WriteLine("입력한 숫자 : " + output);
            }
            else
            {
                Console.WriteLine("숫자를 입력해주세요!");
            }

            int x = 0; int y = 0;
            int vx = 1; int vy = 1;
            Console.WriteLine("현재 좌표 : (" + x + ", " + y + ")");
            NextPos(x, y, vx, vy, out x, out y);
            Console.WriteLine("다음 좌표 : (" + x + ", " + y + ")");

            // 구조체
            Point point;
            point.x = 10;
            point.y = 10;
            point = new Point(3, 5);
            Console.WriteLine(point.x + " / " + point.y);

            PointClass pointClassA = new PointClass(10, 20);
            PointClass pointClassB = pointClassA;
            pointClassB.x = 100; pointClassB.y = 200;
            Console.WriteLine(pointClassA.x + " / " + pointClassA.y);
            Console.WriteLine(pointClassB.x + " / " + pointClassB.y);

            PointStruct pointStructA = new PointStruct(10, 20);
            PointStruct pointStructB = pointStructA;
            pointStructB.x = 100; pointStructB.y = 200;
            Console.WriteLine(pointStructA.x + " / " + pointStructA.y);
            Console.WriteLine(pointStructB.x + " / " + pointStructB.y);

            using (Dummy dummy = new Dummy())
            {
                List<Product> list = new List<Product>()
            {
                new Product() { Name = "고구마", Price = 5000},
                new Product() { Name = "사과", Price = 2400},
                new Product() { Name = "바나나", Price = 2000},
                new Product() { Name = "배", Price = 9000},
            };

                list.Sort();
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
            }

            IBasic basic = new TestClass();
            //basic.something();
            (basic as TestClass).someting();

            // 다중 상속
            Child c = new Child();
            Parent childAsParent = c;
            IDisposable childAsDispoable = c;
            IComparable<Child> childAsComparable = c;

            // 스트림
            File.WriteAllText(@"c:\Temp\test.txt", "문자열 메시지를 씁니다");
            Console.WriteLine(File.ReadAllText(@"c:\Temp\test.txt"));

            // 스트림으로 쓰기
            using (StreamWriter writer = new StreamWriter(@"c:\temp\test.txt"))
            {
                writer.WriteLine("안녕하세요");
                writer.WriteLine("StreamWriter 클래스를 사용해");
                writer.Write("글자를 ");
                writer.Write("여러줄 ");
                writer.Write("입력해봅니다");

                for (int i = 0; i < 10; i++)
                {
                    writer.WriteLine("반복문 - " + i); ;
                }
            }

            Console.WriteLine(File.ReadAllText(@"c:\temp\test.txt"));

            // 스트림으로 읽기
            using(StreamReader reader = new StreamReader(@"c:\temp\test.txt"))
            {
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

            // 예외처리
            string[] array = { "가", "나" };
            Boolean isInputLoop = true;

            while (isInputLoop)
            {
                Console.WriteLine("숫자를 입력해주세요 [0 ~ " + (array.Length - 1) + "] : ");

                string input = Console.ReadLine();
                try
                {
                    int index = int.Parse(input);
                    Console.WriteLine("입력한 위치의 값은 '" + array[index] + "' 입니다.");
                    isInputLoop = false;
                }
               /* catch (IndexOutOfRangeException exception)
                {
                    Console.WriteLine("0 이상 " + array.Length + " 미만 값을 입력하세요");
                    //Console.WriteLine(exception.GetType());
                }
                catch (FormatException exception)
                {
                    Console.WriteLine("숫자가 아닌 것을 입력하셨습니다.");
                    //Console.WriteLine(exception.GetType());
                }*/
               // catch(var exception) - var는 예외 매개변수 부분에서 사용 불가능
                catch (Exception exception)
                {
                    Console.WriteLine("예외가 발생했습니다.");
                    Console.WriteLine("GetType : " + exception.GetType());
                    Console.WriteLine("Message : " + exception.Message);
                    Console.WriteLine("StackTrace : " + exception.StackTrace);
                }
                finally
                {
                    //Console.WriteLine("프로그램이 종료되었습니다.");
                }
            }
            
        }

        class TestClass : IBasic
        {
            public void someting() { }
            public int TestProperty { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public int TestInstanceMethod()
            {
                throw new NotImplementedException();
            }
        }

        class Dummy : IDisposable
        {
            public void Dispose()
            {
                Console.WriteLine("Dispose() 실행");
            }
        }

        static void NextPos(int x, int y, int vx, int vy, out int rx, out int ry)
        {
            rx = x + vx;
            ry = y + vy;
        }

        struct Point
        {
            public int x;
            public int y;
            public string testA;
            public string testB;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
                this.testA = "초기화";
                this.testB = "초기화";
            }

            public Point(int x, int y, string test)
            {
                this.x = x;
                this.y = y;
                this.testA = test;
                this.testB = test;
            }
        }

        class PointClass
        {
            public int x;
            public int y;

            public PointClass(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        struct PointStruct
        {
            public int x;
            public int y;

            public PointStruct(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
    }
}
