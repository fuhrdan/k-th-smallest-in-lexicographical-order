//*****************************************************************************
//** 440. K-th Smallest in Lexicographical Order    leetcode                 **
//*****************************************************************************


int countSteps(int n, long curr, long next) {
    int steps = 0;
    while (curr <= n) {
        steps += (int)fmin(n + 1, next) - curr;
        curr *= 10;
        next *= 10;
    }
    return steps;
}

int findKthNumber(int n, int k) {
    long curr = 1;
    k--;  // We are finding the first number, so reduce k by 1.

    while (k > 0) {
        int steps = countSteps(n, curr, curr + 1);
        if (steps <= k) {
            // Move to the next lexicographical number.
            curr++;
            k -= steps;
        } else {
            // Move to the next level (deeper into the tree).
            curr *= 10;
            k--;
        }
    }

    return (int)curr;
}