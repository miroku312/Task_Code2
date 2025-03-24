import sys


def main():
    TC = int(input())
    for _ in range(TC):
        n = int(input())
        a = list(map(int, input().split()))
        tries = 2
        c = [0] * 10
        for num in a:
            c[num] += 1

        is_found = False
        while tries > 0:
            print("- 0")
            sys.stdout.flush()

            n_a = list(map(int, input().split()))
            n_c = [0] * 10
            for num in n_a:
                n_c[num] += 1

            for i in range(1, 10):
                if c[i] + 1 == n_c[i]:
                    t, s = i, n_c[i]
                    a = n_a[:]
                    is_found = True
                    break

            if is_found:
                break

            tries -= 1

        print(f"- {n - s}", end=" ")
        for i in range(n):
            if a[i] != t:
                print(i + 1, end=" ")
        print()
        sys.stdout.flush()

        a = list(map(int, input().split()))[:s]
        tries = 3
        is_found = False

        while tries > 0 and not is_found:
            for i in range(s):
                if a[i] != t:
                    print(f"! {i + 1}")
                    sys.stdout.flush()
                    is_found = True
                    break

            if is_found:
                break

            print("- 0")
            sys.stdout.flush()
            a = list(map(int, input().split()))

            tries -= 1


if __name__ == "__main__":
    main()

