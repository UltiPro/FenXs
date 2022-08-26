#include "unistd.h"
#include "stdio.h"
#include "windows.h"

int main()
{
    for (int i = 6; i != 0; i--)
    {
        printf("The system will shut down after %d0s.\n", i);
        if (i != 1)
            sleep(10);
    }

    for (int i = 9; i != 0; i--)
    {
        printf("The system will shut down after %ds.\n", i);
        sleep(1);
    }

    system("shutdown -s -t 1");

    return 0;
}