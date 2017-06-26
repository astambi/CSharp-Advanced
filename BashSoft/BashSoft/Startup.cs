namespace BashSoft
{
    public class Startup
    {
        public static void Main()
        {
            // Interim steps

            //IOManager.TraverseDirectory(@"C:\Users\A\Documents\GitHub\C-Advanced\BashSoft");

            //StudentsRepository.InitializeData();
            //StudentsRepository.GetAllStudentsFromCourse("Unity");
            //StudentsRepository.GetStudentScoresFromCourse("Unity", "Ivan");

            //Tester.CompareContent(@"C:\Users\A\Documents\GitHub\C-Advanced\BashSoft\data\test2.txt", @"C:\Users\A\Documents\GitHub\C-Advanced\BashSoft\data\test3.txt");

            //IOManager.CreateDirectoryInCurrentFolder("../../../pesho");
            //IOManager.TraverseDirectory();
            //IOManager.TraverseDirectory(2);

            //IOManager.ChangeCurrentDirectoryAbsolute(@"C:\Windows");
            //IOManager.TraverseDirectory(1);

            //IOManager.CreateDirectoryInCurrentFolder("*2");

            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");

            InputReader.StartReadingCommands();
        }
    }
}
