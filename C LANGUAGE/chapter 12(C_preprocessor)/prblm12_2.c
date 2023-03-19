#include <stdio.h>
#define PI 3.14
#define AOTR(h, b) (h * b * 0.5)
#define POTR(a, b, c) (a + b + c)
#define AOSQ(a) (a * a)
#define POSQ(a) (4 * a)
#define AOCR(r) (PI * r * r)
#define POCR(r) (2 * PI * r)

int main()
{
  int a, x, y, z, ARof_SQ, PRof_SQ, PRof_TR;
  float r, h, b, ARof_CR, PRof_CR, ARof_TR;

  printf("Entr side of squar: ");
  scanf("%d", &a);
  ARof_SQ = AOSQ(a);
  printf("Are of squar is %d\n", ARof_SQ);
  PRof_SQ = POSQ(a);
  printf("perimeter of squar is %d\n", PRof_SQ);

  printf("Enter the radius: ");
  scanf("%f", &r);
  ARof_CR = AOCR(r);
  printf("Area of circle is %f\n", ARof_CR);
  PRof_CR = POCR(r);
  printf("perimeter of circle is %f\n", PRof_CR);

  printf("Enter  hight & base: ");
  scanf("%f %f", &h, &b);
  ARof_TR = AOTR(h, b);
  printf("Area of tringle is %f\n", ARof_TR);

  printf("Enter the 3 sides if tringle: ");
  scanf("%d %d %d", &x, &y, &z);
  PRof_TR = POTR(x, y, z);
  printf("perimeter of tringle is %d\n", PRof_TR);

  return 0;
}