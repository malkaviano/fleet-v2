using System;
using Repo;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new MemoryRepo();

            var runner = new Runner(repo);

            runner.Execute();
        }
    }
}
