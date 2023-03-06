; main.asm the entry point into out os

; creating a starting point and making it global so we can start it when linking
global start
; put the start in the text section which is the code section of our binary
section .text
; set the bit to 32
bits32

start:
    ; printing "ok"
    mov dowrd [0xb8000], 0x2f4b2f42

    ; telling the computer to hold on before reading any instructions
    hlt