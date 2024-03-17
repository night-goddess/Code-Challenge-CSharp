using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challange_CSharp.LeetCode
{
    public static class CourseSchedule
    {
        public static bool CanFinish(int numCourses, int[][] prerequisites)
        {
            bool result = CanFinishWithList(numCourses , prerequisites);
            return result;
        }



        public static bool CanFinishWithListEfficient(int numCourses, int[][] prerequisites)
        {
            // example: [[0,1],[2,3],[1,2],[3,0]]
            // solution
            // create variable for storing intial prerequistites.
            int[][] initialPrerequisites = prerequisites;
            // creae a dictionary  <key: index-zero-number value: keep updating to next prerequisites in the road >
            var dic = new Dictionary<int, HashSet<int>>(); // exp: { 1: {2} , 2: {3 , 0} }
            //for (int i = 0; i < numCourses; i++)
            //{
            //    dic.Add(i , new HashSet<int>());
            //}
            bool result = true;
            for (int i = 0; i < initialPrerequisites.Length; i++)
            {
                int[] element = initialPrerequisites[i];

                if (element[0] == element[1])
                {
                    result = false;
                    break;
                }
                if (dic.ContainsKey(element[0]))
                {
                    dic[element[0]].Add(element[1]);
                }
                else
                {
                    dic[element[0]] = new HashSet<int>() { element[1] };
                }
                HashSet<int> value;
                if (dic.ContainsKey(element[1]))
                {
                    value = dic[element[1]];
                    if (value.Contains(element[0]))
                    {
                        result = false; break;
                    }
                    if (result == false)
                    {
                        break;
                    }
                    dic[element[0]].UnionWith(value);
                }


                foreach (var item in dic)
                {
                    if (item.Value.Any(pre => pre == element[0]))
                    {
                        if (dic[element[0]].Contains(item.Key))
                        {
                            result = false; break;
                        }
                        item.Value.UnionWith(dic[element[0]]);
                    }
                }
                if (result == false)
                {
                    break;
                }
            }
            return result;
        }
        public static bool CanFinishWithList(int numCourses, int[][] prerequisites)
        {
            // example: [[0,1],[2,3],[1,2],[3,0]]
            // solution
            // create variable for storing intial prerequistites.
            var initialPrerequisites = prerequisites;
            // creae a dictionary  <key: index-zero-number value: keep updating to next prerequisites in the road >
            var dic = new Dictionary<int, List<int>>(); // exp: { 1: {2} , 2: {3 , 0} }
            bool result = true;

            for (int i = 0; i < initialPrerequisites.Length; i++)
            {
                int[] element = initialPrerequisites[i];
                if (element[0] == element[1])
                {
                    result = false;
                    break;
                }

                if (!dic.Any(pre => pre.Key == element[0]))
                {
                    dic.Add(element[0], new List<int> { element[1] });

                    if (dic.TryGetValue(element[1], out List<int> value))
                    {
                        if (value.Contains(element[0]))
                        {
                            result = false;
                            break;
                        }
                        dic[element[0]].AddRange(value);
                    }


                    foreach (var item in dic)
                    {
                        if (item.Value.Any(pre => pre == element[0]))
                        {
                            if (dic[element[0]].Contains(item.Key))
                            {
                                result = false;
                                break;
                            }
                            item.Value.AddRange(dic[element[0]]);
                        }
                    }
                    if (result == false)
                    {
                        break;
                    }
                }
                else
                {
                    dic[element[0]].Add(element[1]);
                    foreach (var item in dic)
                    {
                        if (item.Value.Any(pre => pre == element[0]))
                        {
                            if (item.Key == element[1])
                            {
                                result = false;
                                break;
                            }
                            item.Value.Add(element[1]);
                        }
                    }
                    if (result == false)
                    {
                        break;
                    }
                }
            }

            return result;
        }



    }
}

