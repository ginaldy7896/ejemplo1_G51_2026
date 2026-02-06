using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO; // Necesario para guardar archivos, Sin esa directiva, el compilador de C# no reconocería la palabra File
                 // y no sabría cómo guardar la información de tus estudiantes.

public class ControllerScene_3 : MonoBehaviour
{

    List<Student> list_students = new List<Student>();

    public TMP_InputField tnameS;
    public TMP_InputField tmailS;
    public TMP_InputField tageS;
    public TMP_InputField tcourseS;
    public TMP_InputField tcodeS;

    public TextMeshProUGUI panelText; // permite que tu script se comunique con la interfaz visual del panel

    private string filePath; // se utiliza para declarar una variable de tipo cadena (string) que almacenará
                             // la ruta o dirección física en la memoria de tu dispositivo donde se guardará y de donde se leerá el archivo JSON.

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        filePath = Application.persistentDataPath + "/students.json";


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddStudent()
    {
        Student student = new Student(
            tcourseS.text,
            tcodeS.text,
            tnameS.text,
            tmailS.text,
            int.Parse(tageS.text)
        );
        list_students.Add(student);
        Debug.Log("Student added: " + student.NameP + "," + student.MailP + "," + student.AgeP + "," + student.CourseS + "," + student.CodeS);


    }

    public void PrintStudentConsole()
    {
        Debug.Log("----LISTA DE ESTUDIANTES----");
        foreach (Student s in list_students)
        {
            Debug.Log($"Name:{s.NameP}, Age: {s.AgeP}, Code:{s.CodeS}, Course: {s.CourseS},Mail:{s.MailP} ");

        }
    }

    public void PrintStudentPanel()
    {
        panelText.text = "";
        foreach (Student s in list_students)
        {
            panelText.text += $"Name: {s.NameP} | Age: {s.AgeP} | Code:{s.CodeS} | Course: {s.CourseS} | Mail :{s.MailP} \n";
        }
    }

    public void SaveJson()
    {
        StudentListWrapper wrapper = new StudentListWrapper();
        wrapper.students = list_students;

        string json = JsonUtility.ToJson(wrapper, true);
        File.WriteAllText(filePath, json);
        Debug.Log("Datos guardados en: " + filePath);

    }

    public void LoadJson()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            StudentListWrapper wrapper = JsonUtility.FromJson<StudentListWrapper>(json);

            list_students = wrapper.students;
            Debug.Log("Datos cargados correctamente");
        }
        else
        {
            Debug.LogWarning("No se encontró el archivo Json.");
        }
    }

    [System.Serializable]
    public class StudentListWrapper
    {
        public List<Student> students;
    }
}

