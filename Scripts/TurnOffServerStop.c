#include "windows.h"

int main()
{
    system("taskkill -IM TurnOffServerStart.exe -T -F");

    return 0;
}