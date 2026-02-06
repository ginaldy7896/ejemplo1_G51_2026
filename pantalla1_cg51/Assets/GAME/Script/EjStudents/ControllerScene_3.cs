using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControllerScene_3 : MonoBehaviour
{
    
    List<Student> list_students = new List<Student>();

    public TMP_InputField tnameS;
    public TMP_InputField tmailS;
    public TMP_InputField tageS;
    public TMP_InputField tcourseS;
    public TMP_InputField tcodeS;


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
    
}
