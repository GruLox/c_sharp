namespace Project.Services;

/// <summary>
/// Manages the operations related to students, subjects and grades.
/// </summary>
public class StudentManager(string studentsFileName, string subjectsFileName)
{
    private List<StudentWithSubjects> _students = [];
    private List<Subject> _subjects = [];
    private readonly string _studentsFileName = studentsFileName;
    private readonly string _subjectsFileName = subjectsFileName;
    private int _nextStudentId = 1;
    private const int ITEMS_PER_PAGE = 5;
    

    /// <summary>
    /// Runs the student manager application.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task Run()
    {
        await LoadData();

        AssignSubjectsToStudents();

        // Main loop
        bool running = true;
        while (running)
        {
            ConsoleService.DisplayMainMenu();

            var option = ExtendedConsole.ReadEnum<MainMenuOption>();

            // Handle the selected option
            running = HandleMainMenuOption(option);

            await SaveData();
        }
    }

    #region Option Handling
    private bool HandleMainMenuOption(MainMenuOption option)
    {
        switch (option)
        {
            case MainMenuOption.DisplayStudents:
                DisplayStudents();
                break;
            case MainMenuOption.Add:
                HandleAdditionOption();
                break;
            case MainMenuOption.Modify:
                HandleModificationOption();
                break;
            case MainMenuOption.Exit:
                return false;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
        return true;
    }

    private void HandleAdditionOption()
    {
        ConsoleService.DisplayAddMenu();

        var option = ExtendedConsole.ReadEnum<AddMenuOption>();

        switch (option)
        {
            case AddMenuOption.AddStudent:
                AddStudent();
                break;
            case AddMenuOption.AddSubject:
                AddSubjectToStudent();
                break;
            case AddMenuOption.AddGrade:
                AddGradeToSubjectOfStudent();
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }

    private void HandleModificationOption()
    {
        ConsoleService.DisplayModificationMenu();

        var option = ExtendedConsole.ReadEnum<ModifyMenuOption>();

        switch (option)
        {
            case ModifyMenuOption.ModifyStudent:
                ModifyStudent();
                break;
            case ModifyMenuOption.ModifySubject:
                ModifySubject();
                break;
            case ModifyMenuOption.ModifyGrade:
                ModifyGrade();
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }
    #endregion

    #region Load
    private async Task LoadData()
    {
        try
        {
            _students = await JsonUtilities.LoadDataFromJSON<StudentWithSubjects>(_studentsFileName);
            _subjects = await JsonUtilities.LoadDataFromJSON<Subject>(_subjectsFileName);

            // Update _nextStudentId based on loaded data
            if (_students.Count != 0)
            {
                _nextStudentId = _students.Max(s => s.Id) + 1;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading data: {ex.Message}");
        }
    }

    private void AssignSubjectsToStudents()
    {
        foreach (var student in _students)
        {
            var studentSubjects = _subjects.Where(s => s.StudentId == student.Id).ToList();
            student.Subjects = studentSubjects;
        }
    }
    #endregion

    #region Display

    private void DisplayStudents()
    {
        int page = 1;
        while (true)
        {
            var studentsInPage = GetStudentsInPage(page);

            if (studentsInPage.Count == 0)
            {
                Console.WriteLine("No more students.");

                // Wait for user input before returning to the main menu
                Console.WriteLine("Press any key to return to the main menu.");
                Console.ReadKey(true);
                break;
            }

            Console.Clear();

            studentsInPage.WriteCollectionToConsole();

            Console.WriteLine($"Page {page}. Enter a student's ID to view details, N for next page, P for previous page, or B to go back:");
            string input = ExtendedConsole.ReadString().ToUpper();

            if (input == "N")
            {
                page++;
                continue;
            }
            else if (input == "P")
            {
                if (page > 1) page--;
                continue;
            }
            else if (input == "B")
            {
                break;
            }
            else
            {
                bool isInt = int.TryParse(input, out int studentId);
                if (isInt)
                {
                    ViewStudentDetails(studentId);

                    // Wait for user input before returning to the list
                    Console.WriteLine("Press any key to return to the list.");
                    Console.ReadKey(true);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
        }
    }

    private void ViewStudentDetails(int studentId)
    {
        var student = GetStudentById(studentId);

        Console.Clear();

        if (student is null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        Console.WriteLine(student);

        if (student.Subjects.Count == 0)
        {
            Console.WriteLine("No subjects found for this student.");
            return;
        }

        foreach (var subject in student.Subjects)
        {
            if (subject.Grades.Count == 0)
            {
                Console.WriteLine($"No grades found for {subject.Name}.");
            }
            else
            {
                Console.WriteLine($"{subject.Name} Grades: {string.Join(", ", subject.Grades)}");
            }
        }
    }

    #endregion

    #region Add
    private void AddStudent()
    {
        string name = ExtendedConsole.ReadString("Enter the student's name: ");

        var student = new StudentWithSubjects
        {
            Id = _nextStudentId,
            Name = name,
        };

        _students.Add(student);
        Console.WriteLine("Student added successfully.");
        Thread.Sleep(2000);

        _nextStudentId++;
    }

    private void AddSubjectToStudent()
    {
        _students.WriteCollectionToConsole();
        int studentId = ExtendedConsole.ReadInteger("Enter the student's ID: ", 0);
        var student = GetStudentById(studentId);

        if (student == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        SubjectName subjectName = ExtendedConsole.ReadEnum<SubjectName>("Enter the subject's name: ");

        var subject = new Subject
        {
            Name = subjectName,
            StudentId = studentId,
        };

        _subjects.Add(subject);
        student.Subjects.Add(subject);
        Console.WriteLine("Subject added successfully.");
        Thread.Sleep(2000);
    }

    private void AddGradeToSubjectOfStudent()
    {
        _students.WriteCollectionToConsole();
        int studentId = ExtendedConsole.ReadInteger("Enter the student's ID: ", 0);
        var student = GetStudentById(studentId);

        if (student == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        var studentSubjects = _subjects.Where(s => s.StudentId == studentId).ToList();

        if (studentSubjects.Count == 0)
        {
            Console.WriteLine("No subjects found for this student.");
            return;
        }

        studentSubjects.WriteCollectionToConsole();
        int subjectId = ExtendedConsole.ReadInteger("Enter the subject's ID: ", min: 0);
        var subject = _subjects.FirstOrDefault(s => s.Id == subjectId);

        if (subject == null)
        {
            Console.WriteLine("Subject not found.");
            return;
        }

        int grade = ExtendedConsole.ReadInteger("Enter the grade: ", min: 1, max: 5);

        subject.Grades.Add(grade);
        Console.WriteLine("Grade added successfully.");
        Thread.Sleep(2000);
    }
    #endregion

    #region Modify
    private void ModifyStudent()
    {
        _students.WriteCollectionToConsole();
        int maxId = _students.Max(s => s.Id);
        int studentId = ExtendedConsole.ReadInteger("Enter the student's ID: ", min: 0, max: maxId);
        var student = _students.FirstOrDefault(s => s.Id == studentId);

        if (student == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        string name = ExtendedConsole.ReadString("Enter the new name: ");
        student.Name = name;
        Console.WriteLine("Student modified successfully.");
        Thread.Sleep(2000);
    }

    private void ModifySubject()
    {
        _subjects.WriteCollectionToConsole();
        int subjectId = ExtendedConsole.ReadInteger("Enter the subject's ID: ", 0);
        var subject = _subjects.FirstOrDefault(s => s.Id == subjectId);

        if (subject == null)
        {
            Console.WriteLine("Subject not found.");
            return;
        }

        SubjectName subjectName = ExtendedConsole.ReadEnum<SubjectName>("Enter the new subject's name: ");
        subject.Name = subjectName;
        Console.WriteLine("Subject modified successfully.");
        Thread.Sleep(2000);
    }

    private void ModifyGrade()
    {
        _students.WriteCollectionToConsole();
        int studentId = ExtendedConsole.ReadInteger("Enter the student's ID: ", 0);
        var student = GetStudentById(studentId);

        if (student == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        var studentSubjects = _subjects.Where(s => s.StudentId == studentId).ToList();

        if (!studentSubjects.Any())
        {
            Console.WriteLine("No subjects found for this student.");
            return;
        }

        studentSubjects.WriteCollectionToConsole();
        int subjectId = ExtendedConsole.ReadInteger("Enter the subject's ID: ", 0);
        var subject = _subjects.FirstOrDefault(s => s.Id == subjectId);

        if (subject == null)
        {
            Console.WriteLine("Subject not found.");
            return;
        }

        if (subject.Grades.Count == 0)
        {
            Console.WriteLine("No grades found for this subject.");
            return;
        }

        Console.WriteLine("Grades: ");
        subject.Grades.WriteCollectionToConsole();

        int gradeCount = subject.Grades.Count;
        int gradeIndex = ExtendedConsole.ReadInteger("Enter the index of the grade you want to modify: ", min: 0, max: gradeCount);
        int newGrade = ExtendedConsole.ReadInteger("Enter the new grade: ", min: 1, max: 5);

        var gradesList = subject.Grades.ToList();
        gradesList[gradeIndex] = newGrade;
        subject.Grades = gradesList;
        Console.WriteLine("Grade modified successfully.");
        Thread.Sleep(2000);
    }

    #endregion

    #region Save
    private async Task SaveData()
    {
        try
        {
            var students = _students.Select(s => new Student
            {
                Id = s.Id,
                Name = s.Name,
            }).ToList();
            await JsonUtilities.SaveDataToJSON<Student>(students, _studentsFileName);
            await JsonUtilities.SaveDataToJSON<Subject>(_subjects, _subjectsFileName);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving data: {ex.Message}");
        }
    }
    #endregion

    #region Helper Methods
    private StudentWithSubjects? GetStudentById(int id) =>
        _students.FirstOrDefault(s => s.Id == id);

    private List<StudentWithSubjects> GetStudentsInPage(int page) =>
        _students.Skip((page - 1) * ITEMS_PER_PAGE).Take(ITEMS_PER_PAGE).ToList();
    #endregion
}