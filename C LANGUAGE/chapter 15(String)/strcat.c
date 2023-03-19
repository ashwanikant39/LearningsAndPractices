#include <stdio.h>
#include <string.h>
int main()
{
    char fname[] = "Aditya ";
    char lname[] = "pandey";
    strcat(fname, lname);
    puts(fname);

    return 0;
}