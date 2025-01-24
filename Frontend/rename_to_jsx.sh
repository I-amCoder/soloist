#!/bin/bash

# Find all .js files in src directory and its subdirectories
# Exclude index.js and files in node_modules
find src -type f -name "*.js" ! -name "index.js" ! -path "*/node_modules/*" | while read file; do
    # Get the directory and filename
    dir=$(dirname "$file")
    filename=$(basename "$file")
    
    # Create new filename with .jsx extension
    newfile="$dir/${filename%.js}.jsx"
    
    # Rename the file
    mv "$file" "$newfile"
    echo "Renamed: $file -> $newfile"
done

echo "Conversion complete!" 