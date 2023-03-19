#include <stdio.h>
#include <string.h>

int main()
{
   struct book
   {
      char name[100];
      char author[100];
      float price;
      int pages;
   };

   struct book b1 = {"letusc", "yashbant", 250.00, 464};
   //   printf("Enter the name, price & pages of 3 books:  \n");
   //   scanf("%s %f %d", &b1.name, &b1.price, &b1.pages);
   //   scanf("%s %f %d", &b2.name, &b2.price, &b2.pages);
   //   scanf("%s %f %d", &b3.name, &b3.price, &b3.pages);

   // printf("\n\n...and you entered this\n\n");

   printf("\n%s\n%s\n%f\n%d\n", b1.author, b1.name, b1.price, b1.pages);
   //   printf("%s %f %d\n", b2.name, b2.price, b2.pages);
   //   printf("%s %f %d\n", b3.name, b3.price, b3.pages);

   return 0;
}