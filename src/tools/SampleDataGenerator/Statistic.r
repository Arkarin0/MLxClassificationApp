# Libraries
library(plotly)

tempfile <- "E:/Programming/Machine Learning/src/tools/SampleDataGenerator/bin/Debug/net8.0-windows/tempData.csv"

csvdata <- read.csv(tempfile, header = FALSE)
names(csvdata)[1] <- "Label"
names(csvdata)[2] <- "SurfaceTexture"
names(csvdata)[3] <- "UVAbsorbtionRate"
names(csvdata)[4] <- "MagneticPhase"
names(csvdata)[5] <- "magneticAmplitude"

p1 <- plot_ly(csvdata, x= ~UVAbsorbtionRate, color = ~Label, type="histogram") %>%
  layout(
    xaxis= list(
      range=c(100,10000)
    )
  )

p2 <- plot_ly(csvdata, x= ~SurfaceTexture,color = ~Label, type="histogram") %>%
  layout(
    xaxis= list(
      range=c(0,20)
    )
  )

p3 <- plot_ly(csvdata, x= ~magneticAmplitude, y= ~MagneticPhase, type="histogram2dcontour") %>%
  layout(
    xaxis= list(
      title= 'Amplitude',
      range=c(0,65535)
    ),
    yaxis= list(
      title= 'Phase',
      range=c(0,360)
    )
  )

p4 <- plot_ly(csvdata, x= ~magneticAmplitude, y= ~MagneticPhase, color = ~Label, type="scatter", mode= "markers") %>%
  layout(
    xaxis= list(
      title= 'Amplitude',
      range=c(0,65535)
    ),
    yaxis= list(
      title= 'Phase',
      range=c(0,360)
    )
  )
p4
