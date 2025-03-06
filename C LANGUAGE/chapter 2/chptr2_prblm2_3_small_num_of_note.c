#include <stdio.h>
int main()
{

  int amount, hun_note, aft_hun, fifty_note, aft_fifty, ten_note, aft_ten, five_note, aft_five, two_note, aft_two, one_note;
  printf("\nEnter amount: ");
  scanf("%d", &amount); // suppose 588

  hun_note = amount / 100;   // 5 notes of hundred
  aft_hun = amount % 100;    // remaids 88rs
  fifty_note = aft_hun / 50; // 1 not of 50
  aft_fifty = aft_hun % 50;  // remainds 38
  ten_note = aft_fifty / 10; // 3 notes of 10
  aft_ten = aft_fifty % 10;  // remainds 8
  five_note = aft_ten / 5;   // 1 note of 5
  aft_five = aft_ten % 5;    // remainds 3
  two_note = aft_five / 2;   // 1 note of two
  aft_two = aft_five % 2;    // remainds 1
  one_note = aft_two / 1;    // 1 note of 1

  printf("notes of hundered : %d\n", hun_note);
  printf("notes of fifty : %d\n", fifty_note);
  printf("notes of ten : %d\n", ten_note);
  printf("notes of five : %d\n", five_note);
  printf("coin of two : %d\n", two_note);
  printf("coin of one : %d\n\n", one_note);

  // printf("%d",hun_note);
  printf("%d(Hundred's notes) + %d(Fifty's notes) + %d(Ten's notes) + %d(Five's notes) + %d(Two's coin) + %d(One's coins) \n\n", hun_note, fifty_note, ten_note, five_note, two_note, one_note);
  int total = hun_note + fifty_note + ten_note + five_note + two_note + one_note;
  printf("smallest number of notes= %d", total);
  return 0;
}
