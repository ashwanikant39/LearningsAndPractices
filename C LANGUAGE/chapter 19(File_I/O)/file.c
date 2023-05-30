#include <stdio.h>
int main()
{
    FILE *fptr;
    fptr = fopen("file2.exe", "r");
    int ch;
    fscanf(fptr,"%d ", &ch);
    printf("%d ", ch);
    fscanf(fptr,"%d ", &ch);
    printf("%d ", ch);
    fscanf(fptr,"%d ", &ch);
    printf("%d ", ch);


    // if (fptr == NULL)
    // {
    //     printf("NO");
    // }
    // else
    // {
    //     printf("YEs");
    // }
    // printf("%s",fptr);
    fclose(fptr);

    return 0;
}
