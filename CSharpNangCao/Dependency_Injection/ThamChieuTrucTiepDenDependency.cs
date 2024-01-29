namespace Tham_Chieu_Truc_Tiep_Den_Dependency {
    class ClassA {
        // Field
        ClassB _classB;

        // constructor
        public ClassA(ClassB classB) {
            _classB = classB;
        }
        public void CongViecA() {
            Console.WriteLine("Thực hiện công việc A");

            // thực hiện công việc B
            _classB.CongViecB();
        }
    }
    class ClassB {
        // Field
        ClassC _classC;

        // constructor
        public ClassB(ClassC classC) {
            _classC = classC;
        }
        public void CongViecB() {
            Console.WriteLine("Thực hiện công việc B");

            // thực hiện công việc B
            _classC.CongViecC();
        }
    }
    class ClassC {

        public void CongViecC() {
            Console.WriteLine("Thực hiện công việc C");
        }
    }
}
