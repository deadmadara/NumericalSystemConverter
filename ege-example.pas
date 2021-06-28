program abd;
var r, i, min: integer;
str: string;

function From10To2(a:integer):string;
var res: string;
b,i: integer;
temp: char;
begin
 res := '';
 
while (a<>0) do
begin
  res:=res+IntToStr(a mod 2);
  a:= a div 2;
  end;
 
  for i:= 1 to res.Length div 2 do
    begin
    temp:= res[i];
    res[i] := res[res.Length - i + 1];
    res[res.Length - i + 1] := temp;
end;

From10To2:=res;
end;

function From2To10(a:string):integer;
var k, i, res:integer;
begin
  k:=1;
  
  for i:=1 to a.Length - 1 do
    k:=k*2;
  
  res:=0;
  for i:=1 to a.Length do
  begin
    res:= res + StrToInt(a[i]) * k;
    k:=k div 2;
  end;
  
  From2To10:= res;
end;

begin

min:=10000;

 for i:=1 to 31 do 
  begin
    if (i mod 2 = 0) then 
    begin
      str:= '1' + From10To2(i) + '0';
    end
 else 
   begin
    str:='1'+ '1' + From10To2(i) + '1'+ '1';
   end;
   r:=From2To10(str);
   if (r > 52) and (r < min) then min:=r; 
  end;
  
  writeln(min);
  
end.