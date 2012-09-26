REM http://stackoverflow.com/questions/10137937/c-merge-dll-into-exe-beginners-guide-needed
REM Open CMD and cd to your directory. Let's say: cd C:\test
REM Insert the below code.
REM /out:finish.exe | replace finish.exe with any filename you want.
REM Behind the /out:finish.exe you have to give the files you want to be combined.

del %CD% "\FisherySimulation.exe"

REM cd "C:\_MSmesh_\(my documents)\__PROJECTS__\Fishery Simulation\Fishery Simulation\bin\DEBUG"
REM c:
REM C:\__STANDALONE__\_PROGRAMMING_\MS_ILMerge\ILMerge.exe /target:winexe /targetplatform:"v4,C:\Program Files\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0" /out:FisherySimulation.exe "Fishery Simulation.exe" "IPlugins.dll"


REM cd "C:\_MSmesh_\(my documents)\__PROJECTS__\Fishery Simulation\Fishery Simulation\bin\Release"
REM c:
C:\__STANDALONE__\_PROGRAMMING_\MS_ILMerge\ILMerge.exe /target:winexe /targetplatform:"v4,C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0" /out:FisherySimulation.exe "Fishery Simulation.exe" "IPlugins.dll"
cd %CD%
%drive%
echo %CD%
echo %drive%
pause

