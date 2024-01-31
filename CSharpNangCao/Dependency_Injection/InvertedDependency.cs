namespace Inverted_Dependency {
    interface IClassB {
        public void CongViecB();
    }
    interface IClassC {
        public void CongViecC();
    }
    class ClassC : IClassC {
        public void CongViecC() {
            Console.WriteLine("Thực hiện công việc C");
        }
        // Constructor 
        public ClassC() {
            Console.WriteLine("ClassC được tạo");
        }
    }
    class ClassB : IClassB {
        IClassC c_dependency;
        public void CongViecB() {
            Console.WriteLine("Thực hiện công việc B");
            c_dependency.CongViecC();
        }
        // Constructor 
        public ClassB(IClassC classC) {
            c_dependency = classC;
            Console.WriteLine("ClassB được tạo");
        }
    }
    class ClassB2 : IClassB
    {
        IClassC c_dependency;
        string message;
        public ClassB2(IClassC classc, string mgs)
        {
            c_dependency = classc;
            message = mgs;
            Console.WriteLine("ClassB2 is created");
        }
        public void CongViecB()
        {
            Console.WriteLine(message);
            c_dependency.CongViecC();
        }
    }
    class ClassA {
        IClassB b_dependency;
        public void CongViecA() {
            Console.WriteLine("Thực hiện công việc A");
            b_dependency.CongViecB();
        }
        // Constructor 
        public ClassA(IClassB classB) {
            b_dependency = classB;
            Console.WriteLine("ClassA được tạo");
        }
    }
}