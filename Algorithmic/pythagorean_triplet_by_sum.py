def pythagorean_triplet_by_sum(sum: int) -> None:
    for a in range(1, sum // 3 + 1):
        for b in range(a + 1, sum // 2 + 1):
            c = sum - a - b
            if ((a ** 2) + (b ** 2)) == (c ** 2):
                print(f"{a} < {b} < {c}")


if __name__ == '__main__':
    print("sum 120:")
    pythagorean_triplet_by_sum(120)

    print("\nsum 9870:")
    pythagorean_triplet_by_sum(9870)
