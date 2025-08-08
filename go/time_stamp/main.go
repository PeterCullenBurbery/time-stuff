package main

import (
    "fmt"
    "log"

    "github.com/atotto/clipboard"
    "github.com/PeterCullenBurbery/go_functions_002/v5/date_time_functions"
)

func main() {
    timestamp, err := date_time_functions.Get_timestamp()
    if err != nil {
        log.Fatalf("Failed to get timestamp: %v", err)
    }

    fmt.Println(timestamp)

    // Copy to clipboard using atotto/clipboard package
    if err := clipboard.WriteAll(timestamp); err != nil {
        log.Fatalf("Failed to copy to clipboard: %v", err)
    }
}