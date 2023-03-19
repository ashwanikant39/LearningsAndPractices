#include <stdio.h>
#include <stdio.h>
struct shortListStudentByCGPA /*declair structure*/
{
    int rollNo;
    char name[20];
    float cgpa;
    char skills[100];
} std[40] = {2001511, "Arurag", 8.14, "C java",
             2104921, "Anurag singh", 5.85, "#",
             2104922, "Arshita parahar", 6.48, "C",
             2104923, "gauravi", 7.01, "#",
             2104924, "Riya", 7.29, "#",
             2104926, "Ragini", 7.00, "#",
             2104937, "Shivanhi", 6.94, "#",
             2104928, "Abhishek Baghel", 6.42, "#",
             2104929, "Abhishek Shrotriya", 6.10, "#",
             2104930, "Agam satsangi", 7.08, "C, HTML, CSS, Bootstrap, JS ",
             2104931, "Akash Mishra", 7.05, "#",
             2104932, "Akash Singh", 7.50, "C, C++, JAVA, Python, JS",
             2104934, "Aman verma", 4.80, "#",
             2104935, "Ankit Kumar", 7.44, "#",  
             2104936, "Ankush Raj", 8.14, "C, C++, JAVA, JS",
             2104938, "Aryan gautam", 6.87, "#",
             2104939, "Ashwani Kant", 7.67, "FULLSTACK DEVELOPER- HTML, CSS, JS, C, C++, JAVA & design",
             2104940, "Atul gautam", 6.65, "#",
             2104942, "Bhushan Sharma", 6.12, "Python",
             2104943, "Chirag Agrawal", 6.12, "#",
             2104944, "Gagan yadav", 6.30, "#",
             2104936, "Gaurav tomar", 5.70, "#",
             2104948, "Mannat Sharma", 5.79, "#",
             2104949, "Mayank", 7.16, "#",
             2104950, "Mukesh Kumar", 5.51, "#",
             2104951, "Naman Siodiya", 7.14, "#",
             2104952, "Nishant baghel", 6.39, "#",
             2104954, "Praveen yadav", 5.58, "#",
             2104955, "Rajesh kumar", 6.43, "#",
             2104956, "Ritik kumar", 6.98, "#",
             2104957, "Rohit Kumar", 6.50, "#",
             2104958, "Sachin Dhanjani", 6.62, "JAVASCRIPT",
             2104959, "Sachin pandey", 6.56, "#",
             2104960, "Satyam yadav", 7.26, "#",
             2104961, "Saurabh Kumar", 8.57, "Frontend dev",
             2104962, "Sunil sikarwar", 7.10, "#",
             2104963, "Vinay pratap", 6.66, "#",
             2104964, "Vineet singh", 6.99, "#",
             2104965, "Vivek pratap", 6.72, "#"};

void cgpa() /*this function for printf all student*/
{
    int count = 0;
    for (int i = 0; i <= 38; i++)
    {

        printf("Roll no.- %d\n", std[i].rollNo);
        printf("Name- %s\n", std[i].name);
        printf("CGPA- %f\n", std[i].cgpa);
        printf("Skills- %s\n", std[i].skills);
        printf("\n");
        count++;
    }
    printf("\t\t(Total students= %d)\n\n", count);
}

void AboveCgpa() /* for print above the CGPA*/
{

    float cgpa;
    int count = 0;
    printf("Enter CGPA: ");
    scanf("%f", &cgpa);
    printf("\n");
    for (int i = 0; i <= 38; i++) /*check everypone's CGPA one by one*/
    {
        if (std[i].cgpa >= cgpa) /* match CGPA and print full details*/
        {
            printf("Roll no.- %d\n", std[i].rollNo);
            printf("Name- %s\n", std[i].name);
            printf("CGPA- %f\n", std[i].cgpa);
            printf("Skills- %s\n", std[i].skills);
            printf("\n");
            count++;
        }
    }
    printf("\t\t(Total students above %f CGPA= %d)\n\n", cgpa, count);
}

// void topTen()
// {
//     int i, j, k;
    
//     for (i = 0; i <= 38; i++)
//     {
//         for (j = i + 1; j <= 38; j++)
//             if (std[i].cgpa < std[j].cgpa)
//             {
//                 tem = std[i];
//                 std[i] = std[j];
//                 std[j] = tem;
//             }
//     }

//     for (i = 0; i <= 10; i++)
//     {
//         printf("\n");

//         printf("Roll no.- %d\n", std[i].rollNo);
//         printf("Name- %s\n", std[i].name);
//         printf("CGPA- %f\n", std[i].cgpa);
//         printf("Skills- %s\n", std[i].skills);
//         printf("\n");
//     }
// }

int main()
{
    // cgpa();  /*for print all student*/
    printf("\n\n\t\t\t      ---WELCOME---\n \tThis programme will be shortilisting the students on the basis of their cgpa\n\n \tEnter '1' for search studnets above a CGPA\n \n");

    int choice;
    printf("Enter your choice: "); /*switch for multiple task*/
    scanf("%d", &choice);
    if (choice > 0 && choice < 2)
    {
        switch (choice)
        {
        case 1:
            AboveCgpa();
            break;
        // case 2:
        //     topTen();
        //     break;
        }
    }
    else
    {
        printf("**invalid input**");
    }

    return 0;
}