#include <stdio.h>
#include <string.h>
int main()
{
    char oldstr[] = "aditya";
    char newstr[] = "pandey";
    strcpy(newstr, oldstr);
    puts(newstr);

    return 0;
}