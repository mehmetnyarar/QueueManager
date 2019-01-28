# Queue Manager

Queue Manager is a console application which takes user input and create a queue.

## Available Commands

| Name          | Description                                          | Command                                       |
| ------------- | ---------------------------------------------------- | --------------------------------------------- |
| Enqueue       | Adds items to the queue                              | `-e <n> <phone_number_1> <phone_number_2> -c` |
| Dequeue       | Removes the first item from the queue and returns it | `-d`                                          |
| Sort by id    | Sorts queue items by their IDs                       | `-i`                                          |
| Sort by phone | Sorts queue items by phone numbers                   | `-p`                                          |

Examples           :

```shell
-e 3 +11111111 +33333333 +99999999 +77777777 +55555555
-e 5 +22222222 +88888888 +44444444 +66666666 +00000000 -c
```

## Technical Details

- Development platform: Visual Studio for Mac
- Language: C#
- Type: Console