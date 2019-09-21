using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace string_handling
{
    class Program
    {
        enum StringSplitOptions
        {
            None,
            RemoveEmptyEntries
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Concat("Hello, ", "World!"));

            Console.WriteLine(Concat(new string[] { "p", "r", "o", "g", "ra", "mm" }));

            string[] arr = Split("Hello, World and Goodbye! Check this arr! 9 elements.", ' ');

            string[] arr2 = Split("Чай, Кофе, Лемонад, Водка.", new char[] { ',', '.', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string[] arr3 = Split("Чай, Кофе, Лемонад, Водка.", new char[] { ',', '.', ' ' }, StringSplitOptions.None);


            Console.WriteLine(arr[0] + arr[1] + arr[2]);
            Console.WriteLine();
            Console.WriteLine(IndexOf("Hello Polo, ", "lo"));
            Console.WriteLine(IndexOf("Check this string!", "str"));
            Console.WriteLine(IndexOf("Check this string!", "lo"));
            Console.WriteLine();
            Console.WriteLine(LastIndexOf("Hello, Polo", "lo"));
            Console.WriteLine(LastIndexOf("Check this string!", "this"));
            Console.WriteLine(LastIndexOf("Check this string!", "lo"));
            Console.WriteLine();
            Console.WriteLine(Contains("Hello, Polo", "lo"));
            Console.WriteLine(Contains("Hello, Polo", "ro"));
            Console.WriteLine();
            Console.WriteLine(Substring("Hello, Polo", 7, 4));
            Console.WriteLine(Substring("Hello, World!", 7));
            Console.WriteLine();
            Console.WriteLine(Remove("Hello, World!", 2, 8));
            Console.WriteLine(Remove("Hello, World!", 5));
            Console.WriteLine();
            Console.WriteLine(Insert("Hello, World!", 7, "whole "));
            Console.WriteLine();
            Console.WriteLine(Replace("Hello, whole World, whole Space!", "whole", "pretty"));
            Console.WriteLine();
            Console.WriteLine(ToLower("Hello, World!"));
            Console.WriteLine(ToUpper("Hello, World!"));
            Console.WriteLine();
            Console.WriteLine(Trim("             Hello, Polo!              "));
            Console.WriteLine();
            Console.WriteLine(Trim(",  ! \t --- Hello, Polo!  ,,,!!&& \n ! ,", new char[] { ',', '/', '!', '\t', '\n', '&', ' ' }));
            Console.Write(TrimStart("                Hello, Polo!               "));
            Console.Write(TrimEnd("               Hello, Polo!               "));
            Console.WriteLine(123);









            Console.ReadLine();
        }
        static string Concat(string str1, string str2)
        {
            return str1 + str2;
        }
        static string Concat(string[] strs)
        {
            string result = "";
            for (int i = 0; i < strs.Length; i++)
            {
                result += strs[i];
            }
            return result;
        }
        static string[] Split(string text, char separator)
        {
            List<string> timeArr = new List<string>();
            int count = 0;
            timeArr.Add("");

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == separator)
                {
                    timeArr.Add("");
                    count += 1;
                    continue;
                }

                timeArr[count] += (Convert.ToString(text[i]));
            }

            string[] result = new string[timeArr.Count];

            for (int k = 0; k < result.Length; k++)
            {
                result[k] = timeArr[k];
            }
            return result;
        }
        static string[] Split(string text, char[] separator, StringSplitOptions options)
        {
            List<string> timeArr = new List<string>();
            int count = 0;
            timeArr.Add("");

            for (int i = 0; i < text.Length; i++)
            {
                bool isContain = false;
                for (int k = 0; k < separator.Length; k++)
                {
                    if (text[i] == separator[k])
                    {
                        timeArr.Add("");
                        count += 1;
                        isContain = true;
                        break;
                    }
                }
                if (isContain)
                {
                    continue;
                }
                timeArr[count] += (Convert.ToString(text[i]));
            }


            if (options == StringSplitOptions.RemoveEmptyEntries)
            {
                List<string> removeEmpty = new List<string>();

                for (int i = 0; i < timeArr.Count; i++)
                {
                    if (timeArr[i] != "")
                    {
                        removeEmpty.Add(timeArr[i]);
                    }
                }

                string[] result = new string[removeEmpty.Count];

                for (int k = 0; k < result.Length; k++)
                {
                    result[k] = removeEmpty[k];
                }
                return result;
            }
            else
            {
                string[] result = new string[timeArr.Count];

                for (int k = 0; k < result.Length; k++)
                {
                    result[k] = timeArr[k];
                }
                return result;
            }
        }
        static int IndexOf(string text, string substring)
        {
            for (int i = 0; i < text.Length - substring.Length + 1; i++)
            {
                for (int k = 0; k < substring.Length; k++)
                {
                    if (text[i + k] != substring[k])
                    {
                        break;
                    }
                    if (k == substring.Length - 1)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
        static int LastIndexOf(string text, string substring)
        {
            for (int i = text.Length - substring.Length; i > -1; i--)
            {
                for (int k = 0; k < substring.Length; k++)
                {
                    if (text[i + k] != substring[k])
                    {
                        break;
                    }
                    if (k == substring.Length - 1)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
        static bool Contains(string text, string substring)
        {
            for (int i = 0; i < text.Length - substring.Length + 1; i++)
            {
                for (int k = 0; k < substring.Length; k++)
                {
                    if (text[i + k] != substring[k])
                    {
                        break;
                    }
                    if (k == substring.Length - 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static string Substring(string text, int startIndex, int length)
        {
            string result = "";
            for (int i = startIndex; i < startIndex + length; i++)
            {
                result += text[i];
            }
            return result;
        }
        static string Substring(string text, int startIndex)
        {
            string result = "";
            for (int i = startIndex; i < text.Length; i++)
            {
                result += text[i];
            }
            return result;
        }
        static string Remove(string text, int startIndex, int length)
        {
            string result = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (i >= startIndex && i < startIndex + length)
                {
                    continue;
                }
                result += text[i];
            }
            return result;
        }
        static string Remove(string text, int startIndex)
        {
            string result = "";
            for (int i = 0; i < startIndex; i++)
            {
                result += text[i];
            }
            return result;
        }
        static string Insert(string text, int position, string substring)
        {
            string result = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (i == position)
                    result += substring;

                result += text[i];
            }
            return result;
        }
        static string Replace(string text, string substring, string newstring)
        {
            string result = text;
            for (int i = 0; i < result.Length - substring.Length + 1; i++)
            {
                for (int k = 0; k < substring.Length; k++)
                {
                    if (result[i + k] != substring[k])
                    {
                        break;
                    }
                    if (k == substring.Length - 1)
                    {
                        result = Remove(result, i, substring.Length);
                        result = Insert(result, i, newstring);
                    }
                }
            }
            return result;
        }
        static string ToLower(string text)
        {
            string result = "";
            for (int i = 0; i < text.Length; i++)
            {
                if ((int)text[i] > 64 && (int)text[i] < 91)
                {
                    int smallLetter = ((int)text[i] - 65) + 97;
                    result += Convert.ToChar(smallLetter);
                    continue;
                }
                result += text[i];
            }
            return result;
        }
        static string ToUpper(string text)
        {
            string result = "";
            for (int i = 0; i < text.Length; i++)
            {
                if ((int)text[i] > 96 && (int)text[i] < 123)
                {
                    int smallLetter = ((int)text[i] - 97) + 65;
                    result += Convert.ToChar(smallLetter);
                    continue;
                }
                result += text[i];
            }
            return result;
        }
        static string Trim(string text)
        {
            string timeResult = "";
            string result = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    continue;
                }
                for (int k = 0; k < text.Length - i; k++)
                {
                    timeResult += text[i + k];
                }
                break;
            }

            for (int i = timeResult.Length - 1; i > -1; i--)
            {
                if (timeResult[i] == ' ')
                {
                    continue;
                }
                for (int k = 0; k < i + 1; k++)
                {
                    result += timeResult[k];
                }
                break;
            }
            return result;
        }
        static string Trim(string text, params char[] chars)
        {
            string timeResult = "";
            for (int i = 0; i < text.Length; i++)
            {
                bool contains = false;
                for (int l = 0; l < chars.Length; l++)
                {
                    if (text[i] == chars[l])
                    {
                        contains = true;
                        break;
                    }
                }
                if (!contains)
                {
                    for (int k = 0; k < text.Length - i; k++)
                    {
                        timeResult += text[i + k];
                    }
                    break;
                }

            }
            string result = "";
            for (int i = timeResult.Length - 1; i > -1; i--)
            {
                bool contains = false;
                for (int l = 0; l < chars.Length; l++)
                {
                    if (timeResult[i] == chars[l])
                    {
                        contains = true;
                        break;
                    }
                }
                if (!contains)
                {
                    for (int k = 0; k < i + 1; k++)
                    {
                        result += timeResult[k];
                    }
                    break;
                }
            }
            return result;
        }

        static string TrimStart(string text)
        {
            string result = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    continue;
                }
                for (int k = 0; k < text.Length - i; k++)
                {
                    result += text[i + k];
                }
                break;
            }
            return result;
        }
        static string TrimEnd(string text)
        {
            string result = "";
            for (int i = text.Length - 1; i > -1; i--)
            {
                if (text[i] == ' ')
                {
                    continue;
                }
                for (int k = 0; k < i + 1; k++)
                {
                    result += text[k];
                }
                break;
            }
            return result;
        }







    }
}
