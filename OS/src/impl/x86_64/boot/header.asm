; giving a name for this section
; in this case it is called multiboot header
section .multiboot_header
header_start:

    ; the magic number that muilty boot 2 wil look for
    dd 0Xe85250d6

    : the architecture
    ; in this case it is in protected mode i386 
    dd 0

    ; header length
    dd header_end -header_start

    ; checksum = minus all of the data we have in our header
    ; in this case, the checksum is 0x100000000 minus the magic number plus 0 plus the header length
    dd 0x100000000 -(0Xe85250d6 + 0 + (header_end -header_start))

    ; end tag
    ; basically saying that we dont have any more data
    dw 0
    dw 0
    dd 8
header_end;