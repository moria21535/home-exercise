def user_input(data_storage: list) -> None:
    try:
        number = float(input("Please enter a number. If you want to stop press -1: "))
        data_storage.append(number)
        if number != -1:
            user_input(data_storage)
        else:
            data_storage.remove(-1.0)

    except ValueError as e:
        print(e)
        exit()


def average(numbers: list) -> float:
    return sum(numbers) / len(numbers)


def positive_numbers(numbers: list) -> int:
    return len([num for num in numbers if num > 0])


def main():
    numbers = []
    user_input(numbers)

    print(f"\nAverage of the numbers: {average(numbers)}\n"
          f"The amount of positive numbers: {positive_numbers(numbers)}\n"
          f"The numbers are sorted in ascending order: {sorted(numbers)}")


if __name__ == '__main__':
    main()