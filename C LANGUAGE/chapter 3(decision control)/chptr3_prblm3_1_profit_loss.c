#include <stdio.h>
int main()
{
    float sp, cp, profit, loss;
    printf("enter the cost price: ");
    scanf("\n%f", &cp);
    printf("enter the selling price: ");
    scanf("%f", &sp);

    if (sp > cp)
    {
        printf("profit\n");
        profit = sp - cp;
        printf("he made profit= Rs %f\n", profit);
    }
    else if (cp > sp)
    {
        printf("loss\n");
        loss = cp - sp;
        printf("he made loss= Rs %f\n", loss);
    }
    else
    {
        printf("the selling price and cost price is same so he made nothing");
    }

    return 0;
}