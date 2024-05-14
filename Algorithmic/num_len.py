import math


def num_len(num: int) -> int:
    return math.floor(math.log(num, 10)) + 1


if __name__ == '__main__':
    print(num_len(1234))
    print(num_len(123))
    print(num_len(1))
