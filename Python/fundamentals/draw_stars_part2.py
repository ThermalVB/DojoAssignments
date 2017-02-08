def draw_stars_part2(arr):
    for i in xrange(0, len(arr)):
        if type(arr[i]) is int:
            starCount = arr[i]
            #print starCount
            print "*" * starCount
        else:
            newStr = arr[i]
            strCount = len(arr[i])
            char = newStr[0]
            print char * strCount
            
draw_stars_part2([4, "Tom", 1, "Michael", 5, 7, "Jimmy Smith"])