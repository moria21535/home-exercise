def split_word_into_two(string: str) -> tuple:
    len_str = len(string)
    if len_str % 2 == 0:
        return string[:len_str // 2], string[len_str // 2:]
    return string[:len_str // 2 + 1], string[len_str // 2:]


def is_sorted(word: str) -> bool:
    return word == "".join(sorted(word))


def reverse_word(word: str) -> str:
    return word[::-1]


def is_sorted_polyndrom(word: str) -> bool:
    strings = split_word_into_two(word)
    return strings[0] == reverse_word(strings[1]) and is_sorted(strings[0])


if __name__ == '__main__':
    print(is_sorted_polyndrom("abcdcba"))
    print(is_sorted_polyndrom("mom"))
    print(is_sorted_polyndrom("dad"))
    print(is_sorted_polyndrom("aa"))
    print(is_sorted_polyndrom("a"))


