namespace Project.Services;

public class StudentManager(string studentsFileName, string subjectsFileName)
{
    private List<StudentWithSubjects> _students = [];
    private List<Subject> _subjects = [];
    private readonly string _studentsFileName = studentsFileName;
    private readonly string _subjectsFileName = subjectsFileName;
    private int _nextStudentId = 1;

    public async Task Run()
    {
        await LoadData();
        
        AssignSubjectsToStudents();

        // Main loop
        bool running = true;
        while (running)
        {
            ConsoleService.PrintMenu();

            string option = ExtendedConsole.ReadString();

            // Handle the selected option
            running = HandleOption(option);

            await SaveData();
        }
    }

    #region Option Handling
    private bool HandleOption(string option)
    {
        switch (option)
        {
            case "1":
                AddStudent();
                break;
            case "2":
                AddSubjectToStudent();
                break;
            case "3":
                AddGradeToSubjectOfStudent();
                break;
            case "4":
                HandleModification();
                break;
            case "5":
                return false;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
        return true;
    }

    private void HandleModification()
    {
        ConsoleService.PrintMenuForModification();

        string option = ExtendedConsole.ReadString();

        switch (option)
        {
            case "1":
                ModifyStudent();
                break;
            case "2":
                ModifySubject();
                break;
            case "3":
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

        // Increment the next student ID
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
        int newGrade = ExtendedConsole.ReadInteger("Enter the new grade: ", min: 1,  max: 5);

        var gradesList = subject.Grades.ToList();
        gradesList[gradeIndex] = newGrade;
        subject.Grades = gradesList;
        Console.WriteLine("Grade modified successfully.");
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
    #endregion
}