FROM randomdude/gcc-cross-x86_64-elf

RUN apt-get update 
RUN apt-get upgrade -y
# nasm allows us to compile the assembly code
RUN apt-get install -y nasm
# needed for the grub package to work
RUN apt-get install -y xorriso
# grub is needed to create the final iso file
RUN apt-get install -y grub-pc-bin
RUN apt-get install -y grub-common

# hooking up VOLUME to the dev env to have access to all the files in the env folder
VOLUME /root/env
# setting up the env folder as the starting folder
WORKDIR /root/env 